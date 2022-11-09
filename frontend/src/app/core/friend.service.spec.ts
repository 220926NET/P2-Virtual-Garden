import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing'
import { FriendService } from './friend.service';
import { IFriendRelationship } from '../shared/interface';
import { environment } from 'src/environments/environment';

describe('FriendService', () => {
  let service: FriendService;
  let mockController: HttpTestingController;
  const mockedFriendship: IFriendRelationship = {
    username: "test a",
    friendname: "test b"
  };

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule,
      ]
    });
    mockController = TestBed.inject(HttpTestingController);
    service = TestBed.inject(FriendService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should add a friend', () => {
    service.addFriend(mockedFriendship).subscribe((res => {
      expect(res).toBeTruthy();
      expect(res).toEqual(mockedFriendship);
    }))

    const req = mockController.expectOne(environment.baseApi + 'friend');
    expect(req.request.method).toBe('POST');
    req.flush(mockedFriendship);
  });

  it('should get a friend', () => {
    service.getFriend(mockedFriendship.username).subscribe((res => {
      expect(res).toBeTruthy();
      expect(res).toEqual([mockedFriendship]);
    }))

    const req = mockController.expectOne(environment.baseApi + 'friend');
    expect(req.request.method).toBe('GET');
    req.flush([mockedFriendship]);
  })

  it('should delete a friend', () => {
    service.deleteFriend(mockedFriendship).subscribe((res => {
      expect(res).toBeTruthy();
      expect(res).toEqual(mockedFriendship);
    }))

    const req = mockController.expectOne(environment.baseApi + 'friend');
    expect(req.request.method).toBe('DELETE');
    req.flush(mockedFriendship);
  })
});
